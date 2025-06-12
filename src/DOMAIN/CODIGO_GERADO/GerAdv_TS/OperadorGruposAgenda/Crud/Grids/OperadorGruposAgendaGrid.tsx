//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { OperadorGruposAgendaEmpty } from '../../../Models/OperadorGruposAgenda';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IOperadorGruposAgenda } from '../../Interfaces/interface.OperadorGruposAgenda';
import { OperadorGruposAgendaService } from '../../Services/OperadorGruposAgenda.service';
import { OperadorGruposAgendaApi } from '../../Apis/ApiOperadorGruposAgenda';
import { OperadorGruposAgendaGridMobileComponent } from '../GridsMobile/OperadorGruposAgenda';
import { OperadorGruposAgendaGridDesktopComponent } from '../GridsDesktop/OperadorGruposAgenda';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterOperadorGruposAgenda } from '../../Filters/OperadorGruposAgenda';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import OperadorGruposAgendaWindow from './OperadorGruposAgendaWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useOperadorGruposAgendaList } from '../../Hooks/hookOperadorGruposAgenda';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const OperadorGruposAgendaGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const operadorgruposagendaService = useMemo(() => {
    return new OperadorGruposAgendaService(
    new OperadorGruposAgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: operadorgruposagenda, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useOperadorGruposAgendaList(operadorgruposagendaService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedOperadorGruposAgenda, setSelectedOperadorGruposAgenda] = useState<IOperadorGruposAgenda>(OperadorGruposAgendaEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterOperadorGruposAgenda | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterOperadorGruposAgenda | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterOperadorGruposAgenda);
};
// Handlers para o grid
const handleRowClick = (operadorgruposagenda: IOperadorGruposAgenda) => {
  setSelectedOperadorGruposAgenda(operadorgruposagenda);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedOperadorGruposAgenda(OperadorGruposAgendaEmpty());
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
  const operadorgruposagenda = e.dataItem;
  setDeleteId(operadorgruposagenda.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await operadorgruposagendaService.deleteOperadorGruposAgenda(deleteId);
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
    <OperadorGruposAgendaGridMobileComponent
    data={operadorgruposagenda}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <OperadorGruposAgendaGridDesktopComponent
    data={operadorgruposagenda}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <OperadorGruposAgendaWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedOperadorGruposAgenda={selectedOperadorGruposAgenda}
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
export default OperadorGruposAgendaGrid;