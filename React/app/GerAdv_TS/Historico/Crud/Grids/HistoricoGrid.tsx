//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { HistoricoEmpty } from '../../../Models/Historico';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IHistorico } from '../../Interfaces/interface.Historico';
import { HistoricoService } from '../../Services/Historico.service';
import { HistoricoApi } from '../../Apis/ApiHistorico';
import { HistoricoGridMobileComponent } from '../GridsMobile/Historico';
import { HistoricoGridDesktopComponent } from '../GridsDesktop/Historico';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterHistorico } from '../../Filters/Historico';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import HistoricoWindow from './HistoricoWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useHistoricoList } from '../../Hooks/hookHistorico';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const HistoricoGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const historicoService = useMemo(() => {
    return new HistoricoService(
    new HistoricoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: historico, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useHistoricoList(historicoService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedHistorico, setSelectedHistorico] = useState<IHistorico>(HistoricoEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterHistorico | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterHistorico | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterHistorico);
};
// Handlers para o grid
const handleRowClick = (historico: IHistorico) => {
  setSelectedHistorico(historico);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedHistorico(HistoricoEmpty());
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
  const historico = e.dataItem;
  setDeleteId(historico.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await historicoService.deleteHistorico(deleteId);
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
    <HistoricoGridMobileComponent
    data={historico}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <HistoricoGridDesktopComponent
    data={historico}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <HistoricoWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedHistorico={selectedHistorico}
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
export default HistoricoGrid;