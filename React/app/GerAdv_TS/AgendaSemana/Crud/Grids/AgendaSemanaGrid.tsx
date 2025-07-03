//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { AgendaSemanaEmpty } from '../../../Models/AgendaSemana';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IAgendaSemana } from '../../Interfaces/interface.AgendaSemana';
import { AgendaSemanaService } from '../../Services/AgendaSemana.service';
import { AgendaSemanaApi } from '../../Apis/ApiAgendaSemana';
import { AgendaSemanaGridMobileComponent } from '../GridsMobile/AgendaSemana';
import { AgendaSemanaGridDesktopComponent } from '../GridsDesktop/AgendaSemana';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterAgendaSemana } from '../../Filters/AgendaSemana';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import AgendaSemanaWindow from './AgendaSemanaWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useAgendaSemanaList } from '../../Hooks/hookAgendaSemana';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const AgendaSemanaGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const agendasemanaService = useMemo(() => {
    return new AgendaSemanaService(
    new AgendaSemanaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: agendasemana, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useAgendaSemanaList(agendasemanaService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedAgendaSemana, setSelectedAgendaSemana] = useState<IAgendaSemana>(AgendaSemanaEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterAgendaSemana | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterAgendaSemana | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterAgendaSemana);
};
// Handlers para o grid
const handleRowClick = (agendasemana: IAgendaSemana) => {
  setSelectedAgendaSemana(agendasemana);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedAgendaSemana(AgendaSemanaEmpty());
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
  const agendasemana = e.dataItem;
  setDeleteId(agendasemana.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await agendasemanaService.deleteAgendaSemana(deleteId);
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
    <AgendaSemanaGridMobileComponent
    data={agendasemana}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <AgendaSemanaGridDesktopComponent
    data={agendasemana}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <AgendaSemanaWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedAgendaSemana={selectedAgendaSemana}
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
export default AgendaSemanaGrid;