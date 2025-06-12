//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { TribunalEmpty } from '../../../Models/Tribunal';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ITribunal } from '../../Interfaces/interface.Tribunal';
import { TribunalService } from '../../Services/Tribunal.service';
import { TribunalApi } from '../../Apis/ApiTribunal';
import { TribunalGridMobileComponent } from '../GridsMobile/Tribunal';
import { TribunalGridDesktopComponent } from '../GridsDesktop/Tribunal';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterTribunal } from '../../Filters/Tribunal';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import TribunalWindow from './TribunalWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useTribunalList } from '../../Hooks/hookTribunal';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const TribunalGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const tribunalService = useMemo(() => {
    return new TribunalService(
    new TribunalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: tribunal, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useTribunalList(tribunalService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedTribunal, setSelectedTribunal] = useState<ITribunal>(TribunalEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterTribunal | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterTribunal | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterTribunal);
};
// Handlers para o grid
const handleRowClick = (tribunal: ITribunal) => {
  setSelectedTribunal(tribunal);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedTribunal(TribunalEmpty());
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
  const tribunal = e.dataItem;
  setDeleteId(tribunal.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await tribunalService.deleteTribunal(deleteId);
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
    <TribunalGridMobileComponent
    data={tribunal}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <TribunalGridDesktopComponent
    data={tribunal}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <TribunalWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedTribunal={selectedTribunal}
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
export default TribunalGrid;