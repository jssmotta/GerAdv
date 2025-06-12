//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { AgendaQuemEmpty } from '../../../Models/AgendaQuem';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IAgendaQuem } from '../../Interfaces/interface.AgendaQuem';
import { AgendaQuemService } from '../../Services/AgendaQuem.service';
import { AgendaQuemApi } from '../../Apis/ApiAgendaQuem';
import { AgendaQuemGridMobileComponent } from '../GridsMobile/AgendaQuem';
import { AgendaQuemGridDesktopComponent } from '../GridsDesktop/AgendaQuem';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterAgendaQuem } from '../../Filters/AgendaQuem';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import AgendaQuemWindow from './AgendaQuemWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useAgendaQuemList } from '../../Hooks/hookAgendaQuem';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const AgendaQuemGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const agendaquemService = useMemo(() => {
    return new AgendaQuemService(
    new AgendaQuemApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: agendaquem, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useAgendaQuemList(agendaquemService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedAgendaQuem, setSelectedAgendaQuem] = useState<IAgendaQuem>(AgendaQuemEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterAgendaQuem | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterAgendaQuem | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterAgendaQuem);
};
// Handlers para o grid
const handleRowClick = (agendaquem: IAgendaQuem) => {
  setSelectedAgendaQuem(agendaquem);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedAgendaQuem(AgendaQuemEmpty());
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
  const agendaquem = e.dataItem;
  setDeleteId(agendaquem.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await agendaquemService.deleteAgendaQuem(deleteId);
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
    <AgendaQuemGridMobileComponent
    data={agendaquem}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <AgendaQuemGridDesktopComponent
    data={agendaquem}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <AgendaQuemWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedAgendaQuem={selectedAgendaQuem}
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
export default AgendaQuemGrid;