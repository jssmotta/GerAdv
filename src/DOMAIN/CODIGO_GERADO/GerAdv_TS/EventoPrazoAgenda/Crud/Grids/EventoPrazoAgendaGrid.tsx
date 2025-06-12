//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { EventoPrazoAgendaEmpty } from '../../../Models/EventoPrazoAgenda';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IEventoPrazoAgenda } from '../../Interfaces/interface.EventoPrazoAgenda';
import { EventoPrazoAgendaService } from '../../Services/EventoPrazoAgenda.service';
import { EventoPrazoAgendaApi } from '../../Apis/ApiEventoPrazoAgenda';
import { EventoPrazoAgendaGridMobileComponent } from '../GridsMobile/EventoPrazoAgenda';
import { EventoPrazoAgendaGridDesktopComponent } from '../GridsDesktop/EventoPrazoAgenda';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterEventoPrazoAgenda } from '../../Filters/EventoPrazoAgenda';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import EventoPrazoAgendaWindow from './EventoPrazoAgendaWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useEventoPrazoAgendaList } from '../../Hooks/hookEventoPrazoAgenda';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const EventoPrazoAgendaGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const eventoprazoagendaService = useMemo(() => {
    return new EventoPrazoAgendaService(
    new EventoPrazoAgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: eventoprazoagenda, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useEventoPrazoAgendaList(eventoprazoagendaService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedEventoPrazoAgenda, setSelectedEventoPrazoAgenda] = useState<IEventoPrazoAgenda>(EventoPrazoAgendaEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterEventoPrazoAgenda | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterEventoPrazoAgenda | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterEventoPrazoAgenda);
};
// Handlers para o grid
const handleRowClick = (eventoprazoagenda: IEventoPrazoAgenda) => {
  setSelectedEventoPrazoAgenda(eventoprazoagenda);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedEventoPrazoAgenda(EventoPrazoAgendaEmpty());
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
  const eventoprazoagenda = e.dataItem;
  setDeleteId(eventoprazoagenda.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await eventoprazoagendaService.deleteEventoPrazoAgenda(deleteId);
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
    <EventoPrazoAgendaGridMobileComponent
    data={eventoprazoagenda}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <EventoPrazoAgendaGridDesktopComponent
    data={eventoprazoagenda}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <EventoPrazoAgendaWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedEventoPrazoAgenda={selectedEventoPrazoAgenda}
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
export default EventoPrazoAgendaGrid;