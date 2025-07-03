//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { DivisaoTribunalEmpty } from '../../../Models/DivisaoTribunal';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IDivisaoTribunal } from '../../Interfaces/interface.DivisaoTribunal';
import { DivisaoTribunalService } from '../../Services/DivisaoTribunal.service';
import { DivisaoTribunalApi } from '../../Apis/ApiDivisaoTribunal';
import { DivisaoTribunalGridMobileComponent } from '../GridsMobile/DivisaoTribunal';
import { DivisaoTribunalGridDesktopComponent } from '../GridsDesktop/DivisaoTribunal';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterDivisaoTribunal } from '../../Filters/DivisaoTribunal';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import DivisaoTribunalWindow from './DivisaoTribunalWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useDivisaoTribunalList } from '../../Hooks/hookDivisaoTribunal';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const DivisaoTribunalGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const divisaotribunalService = useMemo(() => {
    return new DivisaoTribunalService(
    new DivisaoTribunalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: divisaotribunal, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useDivisaoTribunalList(divisaotribunalService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedDivisaoTribunal, setSelectedDivisaoTribunal] = useState<IDivisaoTribunal>(DivisaoTribunalEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterDivisaoTribunal | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterDivisaoTribunal | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterDivisaoTribunal);
};
// Handlers para o grid
const handleRowClick = (divisaotribunal: IDivisaoTribunal) => {
  setSelectedDivisaoTribunal(divisaotribunal);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedDivisaoTribunal(DivisaoTribunalEmpty());
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
  const divisaotribunal = e.dataItem;
  setDeleteId(divisaotribunal.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await divisaotribunalService.deleteDivisaoTribunal(deleteId);
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
    <DivisaoTribunalGridMobileComponent
    data={divisaotribunal}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <DivisaoTribunalGridDesktopComponent
    data={divisaotribunal}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <DivisaoTribunalWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedDivisaoTribunal={selectedDivisaoTribunal}
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
export default DivisaoTribunalGrid;