//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { RamalEmpty } from '../../../Models/Ramal';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IRamal } from '../../Interfaces/interface.Ramal';
import { RamalService } from '../../Services/Ramal.service';
import { RamalApi } from '../../Apis/ApiRamal';
import { RamalGridMobileComponent } from '../GridsMobile/Ramal';
import { RamalGridDesktopComponent } from '../GridsDesktop/Ramal';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterRamal } from '../../Filters/Ramal';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import RamalWindow from './RamalWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useRamalList } from '../../Hooks/hookRamal';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const RamalGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const ramalService = useMemo(() => {
    return new RamalService(
    new RamalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: ramal, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useRamalList(ramalService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedRamal, setSelectedRamal] = useState<IRamal>(RamalEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterRamal | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterRamal | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterRamal);
};
// Handlers para o grid
const handleRowClick = (ramal: IRamal) => {
  setSelectedRamal(ramal);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedRamal(RamalEmpty());
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
  const ramal = e.dataItem;
  setDeleteId(ramal.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await ramalService.deleteRamal(deleteId);
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
    <RamalGridMobileComponent
    data={ramal}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <RamalGridDesktopComponent
    data={ramal}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <RamalWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedRamal={selectedRamal}
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
export default RamalGrid;