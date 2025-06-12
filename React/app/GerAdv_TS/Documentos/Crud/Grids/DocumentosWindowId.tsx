// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IDocumentos } from '../../Interfaces/interface.Documentos';
import { DocumentosService } from '../../Services/Documentos.service';
import { DocumentosApi } from '../../Apis/ApiDocumentos';
import DocumentosWindow from './DocumentosWindow';
import {DocumentosEmpty } from '@/app/GerAdv_TS/Models/Documentos';
interface DocumentosWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const DocumentosWindowId: React.FC<DocumentosWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const documentosService = useMemo(() => {
  return new DocumentosService(
  new DocumentosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IDocumentos | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(DocumentosEmpty() as IDocumentos);
      return;
    }
    if (id) {
      const response = await documentosService.fetchDocumentosById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <DocumentosWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedDocumentos={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default DocumentosWindowId;