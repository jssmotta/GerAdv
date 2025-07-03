//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { DocumentosEmpty } from '../../../Models/Documentos';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IDocumentos } from '../../Interfaces/interface.Documentos';
import { DocumentosService } from '../../Services/Documentos.service';
import { DocumentosApi } from '../../Apis/ApiDocumentos';
import { DocumentosGridMobileComponent } from '../GridsMobile/Documentos';
import { DocumentosGridDesktopComponent } from '../GridsDesktop/Documentos';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterDocumentos } from '../../Filters/Documentos';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import DocumentosWindow from './DocumentosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useDocumentosList } from '../../Hooks/hookDocumentos';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const DocumentosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const documentosService = useMemo(() => {
    return new DocumentosService(
    new DocumentosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: documentos, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useDocumentosList(documentosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedDocumentos, setSelectedDocumentos] = useState<IDocumentos>(DocumentosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterDocumentos | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterDocumentos | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterDocumentos);
};
// Handlers para o grid
const handleRowClick = (documentos: IDocumentos) => {
  setSelectedDocumentos(documentos);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedDocumentos(DocumentosEmpty());
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
  const documentos = e.dataItem;
  setDeleteId(documentos.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await documentosService.deleteDocumentos(deleteId);
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
    <DocumentosGridMobileComponent
    data={documentos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <DocumentosGridDesktopComponent
    data={documentos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <DocumentosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedDocumentos={selectedDocumentos}
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
export default DocumentosGrid;