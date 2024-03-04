# usage: python3 stream_quat.py [mac1] [mac2] ... [mac(n)]
from __future__ import print_function
from mbientlab.metawear import MetaWear, libmetawear, parse_value
from mbientlab.metawear.cbindings import *
from time import sleep
from threading import Event
import socket

import platform
import sys

quatList0 = ["0.000","0.000","0.000","0.000"]
quatList1 = ["0.000","0.000","0.000","0.000"]
quatList2 = ["0.000","0.000","0.000","0.000"]

if sys.version_info[0] == 2:
    range = xrange

class State:
    # init
    def __init__(self, device):
        sock = socket.socket(socket.AF_INET, scoket.SOCK_DGRAM)
        serverAddressPort = ("127.0.0.1", 5052)
        self.device = device
        self.samples = 0
        self.callback = FnVoid_VoidP_DataP(self.data_handler)
    # callback
    def data_handler(self, ctx, data):

        values = parse_value(data)

        valuesStr = str(values)

        if self.device.address == "FB:1C:CB:A2:DB:DA":
            quatList0[0] = (valuesStr[valuesStr.index("x") + 4 : valuesStr.index("x") + 9])
            quatList0[1] = (valuesStr[valuesStr.index("y") + 4 : valuesStr.index("y") + 9])
            quatList0[2] = (valuesStr[valuesStr.index("z") + 4 : valuesStr.index("z") + 9])
            quatList0[3] = (valuesStr[valuesStr.index("w") + 4 : valuesStr.index("w") + 9])
        elif self.device.address == "D9:9A:FA:B7:8F:FC":
            quatList1[0] = (valuesStr[valuesStr.index("x") + 4 : valuesStr.index("x") + 9])
            quatList1[1] = (valuesStr[valuesStr.index("y") + 4 : valuesStr.index("y") + 9])
            quatList1[2] = (valuesStr[valuesStr.index("z") + 4 : valuesStr.index("z") + 9])
            quatList1[3] = (valuesStr[valuesStr.index("w") + 4 : valuesStr.index("w") + 9])
        elif self.device.address == "C5:7F:5F:7B:CD:6B":
            quatList2[0] = (valuesStr[valuesStr.index("x") + 4 : valuesStr.index("x") + 9])
            quatList2[1] = (valuesStr[valuesStr.index("y") + 4 : valuesStr.index("y") + 9])
            quatList2[2] = (valuesStr[valuesStr.index("z") + 4 : valuesStr.index("z") + 9])
            quatList2[3] = (valuesStr[valuesStr.index("w") + 4 : valuesStr.index("w") + 9])

        serverAddressPort = ("127.0.0.1", 5052)

        sock.sendto(str.encode(str(values)), serverAddressPort)

        with open('streamQuat.txt','w') as f:
            f.write(quatList0[0] + " " + quatList0[1] + " " + quatList0[2] + " " + quatList0[3] + "\n" + quatList1[0] + " " + quatList1[1] + " " + quatList1[2] + " " + quatList1[3] + "\n" + quatList2[0] + " " + quatList2[1] + " " + quatList2[2] + " " + quatList2[3])  
        
        print("QUAT: %s -> %s" % (self.device.address, parse_value(data)))
        self.samples+= 1

states = []
# connect
for i in range(len(sys.argv) - 1):
    d = MetaWear(sys.argv[i + 1])
    d.connect()
    print("Connected to " + d.address + " over " + ("USB" if d.usb.is_connected else "BLE"))
    states.append(State(d))

# configure
for s in states:
    print("Configuring device")
    # setup ble
    libmetawear.mbl_mw_settings_set_connection_parameters(s.device.board, 7.5, 7.5, 0, 6000)
    sleep(1.5)
    # setup quaternion
    libmetawear.mbl_mw_sensor_fusion_set_mode(s.device.board, SensorFusionMode.IMU_PLUS);
    libmetawear.mbl_mw_sensor_fusion_set_acc_range(s.device.board, SensorFusionAccRange._4G)
    libmetawear.mbl_mw_sensor_fusion_set_gyro_range(s.device.board, SensorFusionGyroRange._2000DPS)
    libmetawear.mbl_mw_sensor_fusion_write_config(s.device.board)
    # get quat signal and subscribe
    signal = libmetawear.mbl_mw_sensor_fusion_get_data_signal(s.device.board, SensorFusionData.QUATERNION);
    libmetawear.mbl_mw_datasignal_subscribe(signal, None, s.callback)
    # start acc, gyro, mag
    libmetawear.mbl_mw_sensor_fusion_enable_data(s.device.board, SensorFusionData.QUATERNION);
    libmetawear.mbl_mw_sensor_fusion_start(s.device.board);

# sleep
sleep(10000.0)

# tear down
for s in states:
    # stop
    libmetawear.mbl_mw_sensor_fusion_stop(s.device.board);
    # unsubscribe to signal
    signal = libmetawear.mbl_mw_sensor_fusion_get_data_signal(s.device.board, SensorFusionData.QUATERNION);
    libmetawear.mbl_mw_datasignal_unsubscribe(signal)
    # disconnect
    libmetawear.mbl_mw_debug_disconnect(s.device.board)

# recap
print("Total Samples Received")
for s in states:
    print("%s -> %d" % (s.device.address, s.samples))
