//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { AgendaRecordsEmpty } from '../../../Models/AgendaRecords';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IAgendaRecords } from '../../Interfaces/interface.AgendaRecords';
import { AgendaRecordsService } from '../../Services/AgendaRecords.service';
import { AgendaRecordsApi } from '../../Apis/ApiAgendaRecords';
import { AgendaRecordsGridMobileComponent } from '../GridsMobile/AgendaRecords';
import { AgendaRecordsGridDesktopComponent } from '../GridsDesktop/AgendaRecords';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterAgendaRecords } from '../../Filters/AgendaRecords';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import AgendaRecordsWindow from './AgendaRecordsWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useAgendaRecordsList } from '../../Hooks/hookAgendaRecords';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const AgendaRecordsGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const agendarecordsService = useMemo(() => {
    return new AgendaRecordsService(
    new AgendaRecordsApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: agendarecords, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useAgendaRecordsList(agendarecordsService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedAgendaRecords, setSelectedAgendaRecords] = useState<IAgendaRecords>(AgendaRecordsEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterAgendaRecords | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterAgendaRecords | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterAgendaRecords);
};
// Handlers para o grid
const handleRowClick = (agendarecords: IAgendaRecords) => {
  setSelectedAgendaRecords(agendarecords);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedAgendaRecords(AgendaRecordsEmpty());
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
  const agendarecords = e.dataItem;
  setDeleteId(agendarecords.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await agendarecordsService.deleteAgendaRecords(deleteId);
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
    <AgendaRecordsGridMobileComponent
    data={agendarecords}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <AgendaRecordsGridDesktopComponent
    data={agendarecords}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <AgendaRecordsWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedAgendaRecords={selectedAgendaRecords}
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
export default AgendaRecordsGrid;