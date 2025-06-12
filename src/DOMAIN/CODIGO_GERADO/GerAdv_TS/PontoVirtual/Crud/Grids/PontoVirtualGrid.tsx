//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { PontoVirtualEmpty } from '../../../Models/PontoVirtual';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IPontoVirtual } from '../../Interfaces/interface.PontoVirtual';
import { PontoVirtualService } from '../../Services/PontoVirtual.service';
import { PontoVirtualApi } from '../../Apis/ApiPontoVirtual';
import { PontoVirtualGridMobileComponent } from '../GridsMobile/PontoVirtual';
import { PontoVirtualGridDesktopComponent } from '../GridsDesktop/PontoVirtual';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterPontoVirtual } from '../../Filters/PontoVirtual';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import PontoVirtualWindow from './PontoVirtualWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { usePontoVirtualList } from '../../Hooks/hookPontoVirtual';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const PontoVirtualGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const pontovirtualService = useMemo(() => {
    return new PontoVirtualService(
    new PontoVirtualApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: pontovirtual, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = usePontoVirtualList(pontovirtualService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedPontoVirtual, setSelectedPontoVirtual] = useState<IPontoVirtual>(PontoVirtualEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterPontoVirtual | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterPontoVirtual | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterPontoVirtual);
};
// Handlers para o grid
const handleRowClick = (pontovirtual: IPontoVirtual) => {
  setSelectedPontoVirtual(pontovirtual);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedPontoVirtual(PontoVirtualEmpty());
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
  const pontovirtual = e.dataItem;
  setDeleteId(pontovirtual.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await pontovirtualService.deletePontoVirtual(deleteId);
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
    <PontoVirtualGridMobileComponent
    data={pontovirtual}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <PontoVirtualGridDesktopComponent
    data={pontovirtual}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <PontoVirtualWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedPontoVirtual={selectedPontoVirtual}
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
export default PontoVirtualGrid;