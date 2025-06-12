//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { DadosProcuracaoEmpty } from '../../../Models/DadosProcuracao';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IDadosProcuracao } from '../../Interfaces/interface.DadosProcuracao';
import { DadosProcuracaoService } from '../../Services/DadosProcuracao.service';
import { DadosProcuracaoApi } from '../../Apis/ApiDadosProcuracao';
import { DadosProcuracaoGridMobileComponent } from '../GridsMobile/DadosProcuracao';
import { DadosProcuracaoGridDesktopComponent } from '../GridsDesktop/DadosProcuracao';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterDadosProcuracao } from '../../Filters/DadosProcuracao';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import DadosProcuracaoWindow from './DadosProcuracaoWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useDadosProcuracaoList } from '../../Hooks/hookDadosProcuracao';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const DadosProcuracaoGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const dadosprocuracaoService = useMemo(() => {
    return new DadosProcuracaoService(
    new DadosProcuracaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: dadosprocuracao, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useDadosProcuracaoList(dadosprocuracaoService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedDadosProcuracao, setSelectedDadosProcuracao] = useState<IDadosProcuracao>(DadosProcuracaoEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterDadosProcuracao | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterDadosProcuracao | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterDadosProcuracao);
};
// Handlers para o grid
const handleRowClick = (dadosprocuracao: IDadosProcuracao) => {
  setSelectedDadosProcuracao(dadosprocuracao);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedDadosProcuracao(DadosProcuracaoEmpty());
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
  const dadosprocuracao = e.dataItem;
  setDeleteId(dadosprocuracao.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await dadosprocuracaoService.deleteDadosProcuracao(deleteId);
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
    <DadosProcuracaoGridMobileComponent
    data={dadosprocuracao}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <DadosProcuracaoGridDesktopComponent
    data={dadosprocuracao}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <DadosProcuracaoWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedDadosProcuracao={selectedDadosProcuracao}
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
export default DadosProcuracaoGrid;