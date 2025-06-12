//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { PrecatoriaEmpty } from '../../../Models/Precatoria';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IPrecatoria } from '../../Interfaces/interface.Precatoria';
import { PrecatoriaService } from '../../Services/Precatoria.service';
import { PrecatoriaApi } from '../../Apis/ApiPrecatoria';
import { PrecatoriaGridMobileComponent } from '../GridsMobile/Precatoria';
import { PrecatoriaGridDesktopComponent } from '../GridsDesktop/Precatoria';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterPrecatoria } from '../../Filters/Precatoria';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import PrecatoriaWindow from './PrecatoriaWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { usePrecatoriaList } from '../../Hooks/hookPrecatoria';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const PrecatoriaGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const precatoriaService = useMemo(() => {
    return new PrecatoriaService(
    new PrecatoriaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: precatoria, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = usePrecatoriaList(precatoriaService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedPrecatoria, setSelectedPrecatoria] = useState<IPrecatoria>(PrecatoriaEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterPrecatoria | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterPrecatoria | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterPrecatoria);
};
// Handlers para o grid
const handleRowClick = (precatoria: IPrecatoria) => {
  setSelectedPrecatoria(precatoria);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedPrecatoria(PrecatoriaEmpty());
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
  const precatoria = e.dataItem;
  setDeleteId(precatoria.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await precatoriaService.deletePrecatoria(deleteId);
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
    <PrecatoriaGridMobileComponent
    data={precatoria}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <PrecatoriaGridDesktopComponent
    data={precatoria}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <PrecatoriaWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedPrecatoria={selectedPrecatoria}
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
export default PrecatoriaGrid;