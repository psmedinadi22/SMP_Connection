from scapy.all import sniff

def packet_handler(packet):
    print(packet.show())


interface = '\Device\NPF_Loopback'  
sniff(iface=interface, prn=packet_handler)
