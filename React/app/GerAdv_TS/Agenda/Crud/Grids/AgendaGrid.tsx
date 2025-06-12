//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { AgendaEmpty } from '../../../Models/Agenda';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IAgenda } from '../../Interfaces/interface.Agenda';
import { AgendaService } from '../../Services/Agenda.service';
import { AgendaApi } from '../../Apis/ApiAgenda';
import { AgendaGridMobileComponent } from '../GridsMobile/Agenda';
import { AgendaGridDesktopComponent } from '../GridsDesktop/Agenda';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterAgenda } from '../../Filters/Agenda';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import AgendaWindow from './AgendaWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useAgendaList } from '../../Hooks/hookAgenda';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const AgendaGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const agendaService = useMemo(() => {
    return new AgendaService(
    new AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: agenda, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useAgendaList(agendaService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedAgenda, setSelectedAgenda] = useState<IAgenda>(AgendaEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterAgenda | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterAgenda | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterAgenda);
};
// Handlers para o grid
const handleRowClick = (agenda: IAgenda) => {
  setSelectedAgenda(agenda);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedAgenda(AgendaEmpty());
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
  const agenda = e.dataItem;
  setDeleteId(agenda.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await agendaService.deleteAgenda(deleteId);
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
    <AgendaGridMobileComponent
    data={agenda}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <AgendaGridDesktopComponent
    data={agenda}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <AgendaWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedAgenda={selectedAgenda}
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
export default AgendaGrid;