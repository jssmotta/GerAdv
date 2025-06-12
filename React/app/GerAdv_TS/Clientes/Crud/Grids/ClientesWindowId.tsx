// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IClientes } from '../../Interfaces/interface.Clientes';
import { ClientesService } from '../../Services/Clientes.service';
import { ClientesApi } from '../../Apis/ApiClientes';
import ClientesWindow from './ClientesWindow';
import {ClientesEmpty } from '@/app/GerAdv_TS/Models/Clientes';
interface ClientesWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ClientesWindowId: React.FC<ClientesWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const clientesService = useMemo(() => {
  return new ClientesService(
  new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IClientes | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(ClientesEmpty() as IClientes);
      return;
    }
    if (id) {
      const response = await clientesService.fetchClientesById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <ClientesWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedClientes={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default ClientesWindowId;