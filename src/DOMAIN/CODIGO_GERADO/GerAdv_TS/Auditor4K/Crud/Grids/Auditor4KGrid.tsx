//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { Auditor4KEmpty } from '../../../Models/Auditor4K';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IAuditor4K } from '../../Interfaces/interface.Auditor4K';
import { Auditor4KService } from '../../Services/Auditor4K.service';
import { Auditor4KApi } from '../../Apis/ApiAuditor4K';
import { Auditor4KGridMobileComponent } from '../GridsMobile/Auditor4K';
import { Auditor4KGridDesktopComponent } from '../GridsDesktop/Auditor4K';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterAuditor4K } from '../../Filters/Auditor4K';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import Auditor4KWindow from './Auditor4KWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useAuditor4KList } from '../../Hooks/hookAuditor4K';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const Auditor4KGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const auditor4kService = useMemo(() => {
    return new Auditor4KService(
    new Auditor4KApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: auditor4k, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useAuditor4KList(auditor4kService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedAuditor4K, setSelectedAuditor4K] = useState<IAuditor4K>(Auditor4KEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterAuditor4K | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterAuditor4K | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterAuditor4K);
};
// Handlers para o grid
const handleRowClick = (auditor4k: IAuditor4K) => {
  setSelectedAuditor4K(auditor4k);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedAuditor4K(Auditor4KEmpty());
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
  const auditor4k = e.dataItem;
  setDeleteId(auditor4k.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await auditor4kService.deleteAuditor4K(deleteId);
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
    <Auditor4KGridMobileComponent
    data={auditor4k}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <Auditor4KGridDesktopComponent
    data={auditor4k}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <Auditor4KWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedAuditor4K={selectedAuditor4K}
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
export default Auditor4KGrid;