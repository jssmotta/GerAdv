// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IModelosDocumentos } from '../../Interfaces/interface.ModelosDocumentos';
import { ModelosDocumentosService } from '../../Services/ModelosDocumentos.service';
import { ModelosDocumentosApi } from '../../Apis/ApiModelosDocumentos';
import ModelosDocumentosWindow from './ModelosDocumentosWindow';
import {ModelosDocumentosEmpty } from '@/app/GerAdv_TS/Models/ModelosDocumentos';
interface ModelosDocumentosWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const ModelosDocumentosWindowId: React.FC<ModelosDocumentosWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const modelosdocumentosService = useMemo(() => {
  return new ModelosDocumentosService(
  new ModelosDocumentosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IModelosDocumentos | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(ModelosDocumentosEmpty() as IModelosDocumentos);
      return;
    }
    if (id) {
      const response = await modelosdocumentosService.fetchModelosDocumentosById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <ModelosDocumentosWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedModelosDocumentos={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default ModelosDocumentosWindowId;