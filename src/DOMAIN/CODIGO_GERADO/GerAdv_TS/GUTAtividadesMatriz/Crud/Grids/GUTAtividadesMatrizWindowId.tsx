// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IGUTAtividadesMatriz } from '../../Interfaces/interface.GUTAtividadesMatriz';
import { GUTAtividadesMatrizService } from '../../Services/GUTAtividadesMatriz.service';
import { GUTAtividadesMatrizApi } from '../../Apis/ApiGUTAtividadesMatriz';
import GUTAtividadesMatrizWindow from './GUTAtividadesMatrizWindow';
import {GUTAtividadesMatrizEmpty } from '@/app/GerAdv_TS/Models/GUTAtividadesMatriz';
interface GUTAtividadesMatrizWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const GUTAtividadesMatrizWindowId: React.FC<GUTAtividadesMatrizWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const gutatividadesmatrizService = useMemo(() => {
  return new GUTAtividadesMatrizService(
  new GUTAtividadesMatrizApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IGUTAtividadesMatriz | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(GUTAtividadesMatrizEmpty() as IGUTAtividadesMatriz);
      return;
    }
    if (id) {
      const response = await gutatividadesmatrizService.fetchGUTAtividadesMatrizById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <GUTAtividadesMatrizWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedGUTAtividadesMatriz={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default GUTAtividadesMatrizWindowId;