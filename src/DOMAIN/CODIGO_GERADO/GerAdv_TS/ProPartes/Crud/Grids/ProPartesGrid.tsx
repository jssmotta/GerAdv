//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ProPartesEmpty } from '../../../Models/ProPartes';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IProPartes } from '../../Interfaces/interface.ProPartes';
import { ProPartesService } from '../../Services/ProPartes.service';
import { ProPartesApi } from '../../Apis/ApiProPartes';
import { ProPartesGridMobileComponent } from '../GridsMobile/ProPartes';
import { ProPartesGridDesktopComponent } from '../GridsDesktop/ProPartes';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterProPartes } from '../../Filters/ProPartes';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ProPartesWindow from './ProPartesWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useProPartesList } from '../../Hooks/hookProPartes';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const ProPartesGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const propartesService = useMemo(() => {
    return new ProPartesService(
    new ProPartesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: propartes, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useProPartesList(propartesService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedProPartes, setSelectedProPartes] = useState<IProPartes>(ProPartesEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterProPartes | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterProPartes | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterProPartes);
};
// Handlers para o grid
const handleRowClick = (propartes: IProPartes) => {
  setSelectedProPartes(propartes);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedProPartes(ProPartesEmpty());
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
  const propartes = e.dataItem;
  setDeleteId(propartes.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await propartesService.deleteProPartes(deleteId);
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
    <ProPartesGridMobileComponent
    data={propartes}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ProPartesGridDesktopComponent
    data={propartes}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ProPartesWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedProPartes={selectedProPartes}
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
export default ProPartesGrid;