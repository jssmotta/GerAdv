//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { SituacaoEmpty } from '../../../Models/Situacao';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ISituacao } from '../../Interfaces/interface.Situacao';
import { SituacaoService } from '../../Services/Situacao.service';
import { SituacaoApi } from '../../Apis/ApiSituacao';
import { SituacaoGridMobileComponent } from '../GridsMobile/Situacao';
import { SituacaoGridDesktopComponent } from '../GridsDesktop/Situacao';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterSituacao } from '../../Filters/Situacao';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import SituacaoWindow from './SituacaoWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useSituacaoList } from '../../Hooks/hookSituacao';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const SituacaoGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const situacaoService = useMemo(() => {
    return new SituacaoService(
    new SituacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: situacao, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useSituacaoList(situacaoService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedSituacao, setSelectedSituacao] = useState<ISituacao>(SituacaoEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterSituacao | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterSituacao | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterSituacao);
};
// Handlers para o grid
const handleRowClick = (situacao: ISituacao) => {
  setSelectedSituacao(situacao);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedSituacao(SituacaoEmpty());
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
  const situacao = e.dataItem;
  setDeleteId(situacao.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await situacaoService.deleteSituacao(deleteId);
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
    <SituacaoGridMobileComponent
    data={situacao}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <SituacaoGridDesktopComponent
    data={situacao}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <SituacaoWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedSituacao={selectedSituacao}
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
export default SituacaoGrid;