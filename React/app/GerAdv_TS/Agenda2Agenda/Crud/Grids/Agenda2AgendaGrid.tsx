//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { Agenda2AgendaEmpty } from '../../../Models/Agenda2Agenda';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IAgenda2Agenda } from '../../Interfaces/interface.Agenda2Agenda';
import { Agenda2AgendaService } from '../../Services/Agenda2Agenda.service';
import { Agenda2AgendaApi } from '../../Apis/ApiAgenda2Agenda';
import { Agenda2AgendaGridMobileComponent } from '../GridsMobile/Agenda2Agenda';
import { Agenda2AgendaGridDesktopComponent } from '../GridsDesktop/Agenda2Agenda';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterAgenda2Agenda } from '../../Filters/Agenda2Agenda';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import Agenda2AgendaWindow from './Agenda2AgendaWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useAgenda2AgendaList } from '../../Hooks/hookAgenda2Agenda';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const Agenda2AgendaGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const agenda2agendaService = useMemo(() => {
    return new Agenda2AgendaService(
    new Agenda2AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: agenda2agenda, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useAgenda2AgendaList(agenda2agendaService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedAgenda2Agenda, setSelectedAgenda2Agenda] = useState<IAgenda2Agenda>(Agenda2AgendaEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterAgenda2Agenda | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterAgenda2Agenda | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterAgenda2Agenda);
};
// Handlers para o grid
const handleRowClick = (agenda2agenda: IAgenda2Agenda) => {
  setSelectedAgenda2Agenda(agenda2agenda);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedAgenda2Agenda(Agenda2AgendaEmpty());
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
  const agenda2agenda = e.dataItem;
  setDeleteId(agenda2agenda.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await agenda2agendaService.deleteAgenda2Agenda(deleteId);
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
    <Agenda2AgendaGridMobileComponent
    data={agenda2agenda}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <Agenda2AgendaGridDesktopComponent
    data={agenda2agenda}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <Agenda2AgendaWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedAgenda2Agenda={selectedAgenda2Agenda}
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
export default Agenda2AgendaGrid;