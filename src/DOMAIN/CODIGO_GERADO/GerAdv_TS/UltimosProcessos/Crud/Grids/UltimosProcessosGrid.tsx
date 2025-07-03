//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { UltimosProcessosEmpty } from '../../../Models/UltimosProcessos';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IUltimosProcessos } from '../../Interfaces/interface.UltimosProcessos';
import { UltimosProcessosService } from '../../Services/UltimosProcessos.service';
import { UltimosProcessosApi } from '../../Apis/ApiUltimosProcessos';
import { UltimosProcessosGridMobileComponent } from '../GridsMobile/UltimosProcessos';
import { UltimosProcessosGridDesktopComponent } from '../GridsDesktop/UltimosProcessos';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterUltimosProcessos } from '../../Filters/UltimosProcessos';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import UltimosProcessosWindow from './UltimosProcessosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useUltimosProcessosList } from '../../Hooks/hookUltimosProcessos';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const UltimosProcessosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const ultimosprocessosService = useMemo(() => {
    return new UltimosProcessosService(
    new UltimosProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: ultimosprocessos, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useUltimosProcessosList(ultimosprocessosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedUltimosProcessos, setSelectedUltimosProcessos] = useState<IUltimosProcessos>(UltimosProcessosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterUltimosProcessos | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterUltimosProcessos | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterUltimosProcessos);
};
// Handlers para o grid
const handleRowClick = (ultimosprocessos: IUltimosProcessos) => {
  setSelectedUltimosProcessos(ultimosprocessos);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedUltimosProcessos(UltimosProcessosEmpty());
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
  const ultimosprocessos = e.dataItem;
  setDeleteId(ultimosprocessos.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await ultimosprocessosService.deleteUltimosProcessos(deleteId);
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
    <UltimosProcessosGridMobileComponent
    data={ultimosprocessos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <UltimosProcessosGridDesktopComponent
    data={ultimosprocessos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <UltimosProcessosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedUltimosProcessos={selectedUltimosProcessos}
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
export default UltimosProcessosGrid;