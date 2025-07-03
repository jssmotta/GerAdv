//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { TiposAcaoEmpty } from '../../../Models/TiposAcao';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ITiposAcao } from '../../Interfaces/interface.TiposAcao';
import { TiposAcaoService } from '../../Services/TiposAcao.service';
import { TiposAcaoApi } from '../../Apis/ApiTiposAcao';
import { TiposAcaoGridMobileComponent } from '../GridsMobile/TiposAcao';
import { TiposAcaoGridDesktopComponent } from '../GridsDesktop/TiposAcao';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterTiposAcao } from '../../Filters/TiposAcao';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import TiposAcaoWindow from './TiposAcaoWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useTiposAcaoList } from '../../Hooks/hookTiposAcao';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const TiposAcaoGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const tiposacaoService = useMemo(() => {
    return new TiposAcaoService(
    new TiposAcaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: tiposacao, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useTiposAcaoList(tiposacaoService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedTiposAcao, setSelectedTiposAcao] = useState<ITiposAcao>(TiposAcaoEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterTiposAcao | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterTiposAcao | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterTiposAcao);
};
// Handlers para o grid
const handleRowClick = (tiposacao: ITiposAcao) => {
  setSelectedTiposAcao(tiposacao);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedTiposAcao(TiposAcaoEmpty());
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
  const tiposacao = e.dataItem;
  setDeleteId(tiposacao.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await tiposacaoService.deleteTiposAcao(deleteId);
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
    <TiposAcaoGridMobileComponent
    data={tiposacao}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <TiposAcaoGridDesktopComponent
    data={tiposacao}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <TiposAcaoWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedTiposAcao={selectedTiposAcao}
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
export default TiposAcaoGrid;