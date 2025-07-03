//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ProDepositosEmpty } from '../../../Models/ProDepositos';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IProDepositos } from '../../Interfaces/interface.ProDepositos';
import { ProDepositosService } from '../../Services/ProDepositos.service';
import { ProDepositosApi } from '../../Apis/ApiProDepositos';
import { ProDepositosGridMobileComponent } from '../GridsMobile/ProDepositos';
import { ProDepositosGridDesktopComponent } from '../GridsDesktop/ProDepositos';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterProDepositos } from '../../Filters/ProDepositos';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ProDepositosWindow from './ProDepositosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useProDepositosList } from '../../Hooks/hookProDepositos';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const ProDepositosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const prodepositosService = useMemo(() => {
    return new ProDepositosService(
    new ProDepositosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: prodepositos, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useProDepositosList(prodepositosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedProDepositos, setSelectedProDepositos] = useState<IProDepositos>(ProDepositosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterProDepositos | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterProDepositos | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterProDepositos);
};
// Handlers para o grid
const handleRowClick = (prodepositos: IProDepositos) => {
  setSelectedProDepositos(prodepositos);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedProDepositos(ProDepositosEmpty());
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
  const prodepositos = e.dataItem;
  setDeleteId(prodepositos.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await prodepositosService.deleteProDepositos(deleteId);
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
    <ProDepositosGridMobileComponent
    data={prodepositos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ProDepositosGridDesktopComponent
    data={prodepositos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ProDepositosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedProDepositos={selectedProDepositos}
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
export default ProDepositosGrid;