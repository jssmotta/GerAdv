//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { FaseEmpty } from '../../../Models/Fase';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IFase } from '../../Interfaces/interface.Fase';
import { FaseService } from '../../Services/Fase.service';
import { FaseApi } from '../../Apis/ApiFase';
import { FaseGridMobileComponent } from '../GridsMobile/Fase';
import { FaseGridDesktopComponent } from '../GridsDesktop/Fase';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterFase } from '../../Filters/Fase';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import FaseWindow from './FaseWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useFaseList } from '../../Hooks/hookFase';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const FaseGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const faseService = useMemo(() => {
    return new FaseService(
    new FaseApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: fase, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useFaseList(faseService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedFase, setSelectedFase] = useState<IFase>(FaseEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterFase | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterFase | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterFase);
};
// Handlers para o grid
const handleRowClick = (fase: IFase) => {
  setSelectedFase(fase);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedFase(FaseEmpty());
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
  const fase = e.dataItem;
  setDeleteId(fase.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await faseService.deleteFase(deleteId);
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
    <FaseGridMobileComponent
    data={fase}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <FaseGridDesktopComponent
    data={fase}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <FaseWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedFase={selectedFase}
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
export default FaseGrid;