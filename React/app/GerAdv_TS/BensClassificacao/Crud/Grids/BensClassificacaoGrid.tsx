//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { BensClassificacaoEmpty } from '../../../Models/BensClassificacao';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IBensClassificacao } from '../../Interfaces/interface.BensClassificacao';
import { BensClassificacaoService } from '../../Services/BensClassificacao.service';
import { BensClassificacaoApi } from '../../Apis/ApiBensClassificacao';
import { BensClassificacaoGridMobileComponent } from '../GridsMobile/BensClassificacao';
import { BensClassificacaoGridDesktopComponent } from '../GridsDesktop/BensClassificacao';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterBensClassificacao } from '../../Filters/BensClassificacao';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import BensClassificacaoWindow from './BensClassificacaoWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useBensClassificacaoList } from '../../Hooks/hookBensClassificacao';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const BensClassificacaoGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const bensclassificacaoService = useMemo(() => {
    return new BensClassificacaoService(
    new BensClassificacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: bensclassificacao, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useBensClassificacaoList(bensclassificacaoService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedBensClassificacao, setSelectedBensClassificacao] = useState<IBensClassificacao>(BensClassificacaoEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterBensClassificacao | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterBensClassificacao | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterBensClassificacao);
};
// Handlers para o grid
const handleRowClick = (bensclassificacao: IBensClassificacao) => {
  setSelectedBensClassificacao(bensclassificacao);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedBensClassificacao(BensClassificacaoEmpty());
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
  const bensclassificacao = e.dataItem;
  setDeleteId(bensclassificacao.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await bensclassificacaoService.deleteBensClassificacao(deleteId);
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
    <BensClassificacaoGridMobileComponent
    data={bensclassificacao}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <BensClassificacaoGridDesktopComponent
    data={bensclassificacao}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <BensClassificacaoWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedBensClassificacao={selectedBensClassificacao}
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
export default BensClassificacaoGrid;