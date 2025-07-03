//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { AgendaFinanceiroEmpty } from '../../../Models/AgendaFinanceiro';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IAgendaFinanceiro } from '../../Interfaces/interface.AgendaFinanceiro';
import { AgendaFinanceiroService } from '../../Services/AgendaFinanceiro.service';
import { AgendaFinanceiroApi } from '../../Apis/ApiAgendaFinanceiro';
import { AgendaFinanceiroGridMobileComponent } from '../GridsMobile/AgendaFinanceiro';
import { AgendaFinanceiroGridDesktopComponent } from '../GridsDesktop/AgendaFinanceiro';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterAgendaFinanceiro } from '../../Filters/AgendaFinanceiro';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import AgendaFinanceiroWindow from './AgendaFinanceiroWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useAgendaFinanceiroList } from '../../Hooks/hookAgendaFinanceiro';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const AgendaFinanceiroGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const agendafinanceiroService = useMemo(() => {
    return new AgendaFinanceiroService(
    new AgendaFinanceiroApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: agendafinanceiro, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useAgendaFinanceiroList(agendafinanceiroService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedAgendaFinanceiro, setSelectedAgendaFinanceiro] = useState<IAgendaFinanceiro>(AgendaFinanceiroEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterAgendaFinanceiro | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterAgendaFinanceiro | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterAgendaFinanceiro);
};
// Handlers para o grid
const handleRowClick = (agendafinanceiro: IAgendaFinanceiro) => {
  setSelectedAgendaFinanceiro(agendafinanceiro);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedAgendaFinanceiro(AgendaFinanceiroEmpty());
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
  const agendafinanceiro = e.dataItem;
  setDeleteId(agendafinanceiro.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await agendafinanceiroService.deleteAgendaFinanceiro(deleteId);
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
    <AgendaFinanceiroGridMobileComponent
    data={agendafinanceiro}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <AgendaFinanceiroGridDesktopComponent
    data={agendafinanceiro}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <AgendaFinanceiroWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedAgendaFinanceiro={selectedAgendaFinanceiro}
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
export default AgendaFinanceiroGrid;