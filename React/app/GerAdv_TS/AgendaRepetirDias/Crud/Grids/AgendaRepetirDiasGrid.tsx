//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { AgendaRepetirDiasEmpty } from '../../../Models/AgendaRepetirDias';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IAgendaRepetirDias } from '../../Interfaces/interface.AgendaRepetirDias';
import { AgendaRepetirDiasService } from '../../Services/AgendaRepetirDias.service';
import { AgendaRepetirDiasApi } from '../../Apis/ApiAgendaRepetirDias';
import { AgendaRepetirDiasGridMobileComponent } from '../GridsMobile/AgendaRepetirDias';
import { AgendaRepetirDiasGridDesktopComponent } from '../GridsDesktop/AgendaRepetirDias';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterAgendaRepetirDias } from '../../Filters/AgendaRepetirDias';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import AgendaRepetirDiasWindow from './AgendaRepetirDiasWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useAgendaRepetirDiasList } from '../../Hooks/hookAgendaRepetirDias';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const AgendaRepetirDiasGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const agendarepetirdiasService = useMemo(() => {
    return new AgendaRepetirDiasService(
    new AgendaRepetirDiasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: agendarepetirdias, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useAgendaRepetirDiasList(agendarepetirdiasService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedAgendaRepetirDias, setSelectedAgendaRepetirDias] = useState<IAgendaRepetirDias>(AgendaRepetirDiasEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterAgendaRepetirDias | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterAgendaRepetirDias | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterAgendaRepetirDias);
};
// Handlers para o grid
const handleRowClick = (agendarepetirdias: IAgendaRepetirDias) => {
  setSelectedAgendaRepetirDias(agendarepetirdias);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedAgendaRepetirDias(AgendaRepetirDiasEmpty());
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
  const agendarepetirdias = e.dataItem;
  setDeleteId(agendarepetirdias.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await agendarepetirdiasService.deleteAgendaRepetirDias(deleteId);
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
    <AgendaRepetirDiasGridMobileComponent
    data={agendarepetirdias}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <AgendaRepetirDiasGridDesktopComponent
    data={agendarepetirdias}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <AgendaRepetirDiasWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedAgendaRepetirDias={selectedAgendaRepetirDias}
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
export default AgendaRepetirDiasGrid;