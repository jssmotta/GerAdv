//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ModelosDocumentosEmpty } from '../../../Models/ModelosDocumentos';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IModelosDocumentos } from '../../Interfaces/interface.ModelosDocumentos';
import { ModelosDocumentosService } from '../../Services/ModelosDocumentos.service';
import { ModelosDocumentosApi } from '../../Apis/ApiModelosDocumentos';
import { ModelosDocumentosGridMobileComponent } from '../GridsMobile/ModelosDocumentos';
import { ModelosDocumentosGridDesktopComponent } from '../GridsDesktop/ModelosDocumentos';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterModelosDocumentos } from '../../Filters/ModelosDocumentos';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ModelosDocumentosWindow from './ModelosDocumentosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useModelosDocumentosList } from '../../Hooks/hookModelosDocumentos';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const ModelosDocumentosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const modelosdocumentosService = useMemo(() => {
    return new ModelosDocumentosService(
    new ModelosDocumentosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: modelosdocumentos, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useModelosDocumentosList(modelosdocumentosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedModelosDocumentos, setSelectedModelosDocumentos] = useState<IModelosDocumentos>(ModelosDocumentosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterModelosDocumentos | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterModelosDocumentos | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterModelosDocumentos);
};
// Handlers para o grid
const handleRowClick = (modelosdocumentos: IModelosDocumentos) => {
  setSelectedModelosDocumentos(modelosdocumentos);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedModelosDocumentos(ModelosDocumentosEmpty());
  setShowInc(true);
};
const handleClose = () => {
  setShowInc(false);
};
const handleSuccess = () => {
  setShowInc(false);
  // O hook já escuta as notificações e recarrega automaticamente
};
const handleError = () => {
  setShowInc(false);
};
// Handlers para exclusão
const onDeleteClick = (e: any) => {
  const modelosdocumentos = e.dataItem;
  setDeleteId(modelosdocumentos.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await modelosdocumentosService.deleteModelosDocumentos(deleteId);
      // O hook já escuta as notificações e recarrega automaticamente
    } catch (error) {
    console.error('Erro ao excluir:', error);
    setErrorMessage('Erro ao excluir o registro. Verifique se ele não está vinculado a outros registros.');
  } finally {
  setDeleteId(null);
  setIsModalOpen(false);
}
}
};
const cancelDelete = () => {
  setDeleteId(null);
  setIsModalOpen(false);
};
// Combinar erro do hook com erro local
const displayError = error || errorMessage;
useEffect(() => {
  const unsubscribe = subscribeToNotifications('*', (entity) => {
    if (entity.action == NotifySystemActions.ERROR) {
      return;
    }
    reloadFilter();
  });
  return () => {
    unsubscribe();
  };
}, []);
return (
<>
<AppGridToolbar onAdd={handleAdd} />
{loading && (
  <LoadingSpinner />
  )}
  {isMobile ? (
    <ModelosDocumentosGridMobileComponent
    data={modelosdocumentos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ModelosDocumentosGridDesktopComponent
    data={modelosdocumentos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ModelosDocumentosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedModelosDocumentos={selectedModelosDocumentos}
    />

    <ConfirmationModal
    isOpen={isModalOpen}
    onConfirm={confirmDelete}
    onCancel={cancelDelete}
    message={`Deseja realmente excluir o registro?`}
    />
    <ErrorMessage
    mensagem={displayError}
    setErrorMessage={setErrorMessage}
    />
  </>
);
};
export default ModelosDocumentosGrid;