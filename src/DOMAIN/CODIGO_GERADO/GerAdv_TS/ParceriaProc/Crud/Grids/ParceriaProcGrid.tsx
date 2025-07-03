//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ParceriaProcEmpty } from '../../../Models/ParceriaProc';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IParceriaProc } from '../../Interfaces/interface.ParceriaProc';
import { ParceriaProcService } from '../../Services/ParceriaProc.service';
import { ParceriaProcApi } from '../../Apis/ApiParceriaProc';
import { ParceriaProcGridMobileComponent } from '../GridsMobile/ParceriaProc';
import { ParceriaProcGridDesktopComponent } from '../GridsDesktop/ParceriaProc';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterParceriaProc } from '../../Filters/ParceriaProc';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ParceriaProcWindow from './ParceriaProcWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useParceriaProcList } from '../../Hooks/hookParceriaProc';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const ParceriaProcGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const parceriaprocService = useMemo(() => {
    return new ParceriaProcService(
    new ParceriaProcApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: parceriaproc, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useParceriaProcList(parceriaprocService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedParceriaProc, setSelectedParceriaProc] = useState<IParceriaProc>(ParceriaProcEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterParceriaProc | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterParceriaProc | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterParceriaProc);
};
// Handlers para o grid
const handleRowClick = (parceriaproc: IParceriaProc) => {
  setSelectedParceriaProc(parceriaproc);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedParceriaProc(ParceriaProcEmpty());
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
  const parceriaproc = e.dataItem;
  setDeleteId(parceriaproc.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await parceriaprocService.deleteParceriaProc(deleteId);
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
    <ParceriaProcGridMobileComponent
    data={parceriaproc}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ParceriaProcGridDesktopComponent
    data={parceriaproc}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ParceriaProcWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedParceriaProc={selectedParceriaProc}
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
export default ParceriaProcGrid;