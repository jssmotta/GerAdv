//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { TipoModeloDocumentoEmpty } from '../../../Models/TipoModeloDocumento';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ITipoModeloDocumento } from '../../Interfaces/interface.TipoModeloDocumento';
import { TipoModeloDocumentoService } from '../../Services/TipoModeloDocumento.service';
import { TipoModeloDocumentoApi } from '../../Apis/ApiTipoModeloDocumento';
import { TipoModeloDocumentoGridMobileComponent } from '../GridsMobile/TipoModeloDocumento';
import { TipoModeloDocumentoGridDesktopComponent } from '../GridsDesktop/TipoModeloDocumento';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterTipoModeloDocumento } from '../../Filters/TipoModeloDocumento';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import TipoModeloDocumentoWindow from './TipoModeloDocumentoWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useTipoModeloDocumentoList } from '../../Hooks/hookTipoModeloDocumento';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const TipoModeloDocumentoGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const tipomodelodocumentoService = useMemo(() => {
    return new TipoModeloDocumentoService(
    new TipoModeloDocumentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: tipomodelodocumento, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useTipoModeloDocumentoList(tipomodelodocumentoService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedTipoModeloDocumento, setSelectedTipoModeloDocumento] = useState<ITipoModeloDocumento>(TipoModeloDocumentoEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterTipoModeloDocumento | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterTipoModeloDocumento | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterTipoModeloDocumento);
};
// Handlers para o grid
const handleRowClick = (tipomodelodocumento: ITipoModeloDocumento) => {
  setSelectedTipoModeloDocumento(tipomodelodocumento);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedTipoModeloDocumento(TipoModeloDocumentoEmpty());
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
  const tipomodelodocumento = e.dataItem;
  setDeleteId(tipomodelodocumento.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await tipomodelodocumentoService.deleteTipoModeloDocumento(deleteId);
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
    <TipoModeloDocumentoGridMobileComponent
    data={tipomodelodocumento}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <TipoModeloDocumentoGridDesktopComponent
    data={tipomodelodocumento}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <TipoModeloDocumentoWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedTipoModeloDocumento={selectedTipoModeloDocumento}
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
export default TipoModeloDocumentoGrid;