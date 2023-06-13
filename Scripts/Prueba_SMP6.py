import socket
import textwrap
import eth

def multi_line(prefix, string, size=80):
        size -= len(prefix)
        if isinstance(string, bytes):
                string = ''.join(r'\x{:02x}'.format(byte) for byte in string)
                if size % 2:
                        size -= 1
        return '\n'.join([prefix + line for line in textwrap.wrap(string, size)])

TAB1 = "\t"
TAB2 = "\t\t"
TAB3 = "\t\t\t"

conn = socket.socket(socket.AF_PACKET, socket.SOCK_RAW, socket.ntohs(3))

if __name__ == "__main__":
        while True:
                raw_data, addr = conn.recvfrom(65535)

                dest_mac, src_mac, eth_proto, data = eth.ethernet_unpack(raw_data)
                version, header_len, tos, total_len, identification, x_bit, DFF, MFF, frag_offset, TTL, proto, header_checksum , s_ip, d_ip, data = ip.ip_unpack(data)

                print("Ethernet Frame")
                print(TAB1 + "- Destination Mac : {} , Source Mac : {} , Protocol : {}" .format(str(dest_mac), str(src_mac), str(eth_proto)))
