//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { TipoStatusBiuEmpty } from '../../../Models/TipoStatusBiu';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ITipoStatusBiu } from '../../Interfaces/interface.TipoStatusBiu';
import { TipoStatusBiuService } from '../../Services/TipoStatusBiu.service';
import { TipoStatusBiuApi } from '../../Apis/ApiTipoStatusBiu';
import { TipoStatusBiuGridMobileComponent } from '../GridsMobile/TipoStatusBiu';
import { TipoStatusBiuGridDesktopComponent } from '../GridsDesktop/TipoStatusBiu';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterTipoStatusBiu } from '../../Filters/TipoStatusBiu';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import TipoStatusBiuWindow from './TipoStatusBiuWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useTipoStatusBiuList } from '../../Hooks/hookTipoStatusBiu';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const TipoStatusBiuGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const tipostatusbiuService = useMemo(() => {
    return new TipoStatusBiuService(
    new TipoStatusBiuApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: tipostatusbiu, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useTipoStatusBiuList(tipostatusbiuService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedTipoStatusBiu, setSelectedTipoStatusBiu] = useState<ITipoStatusBiu>(TipoStatusBiuEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterTipoStatusBiu | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterTipoStatusBiu | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterTipoStatusBiu);
};
// Handlers para o grid
const handleRowClick = (tipostatusbiu: ITipoStatusBiu) => {
  setSelectedTipoStatusBiu(tipostatusbiu);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedTipoStatusBiu(TipoStatusBiuEmpty());
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
  const tipostatusbiu = e.dataItem;
  setDeleteId(tipostatusbiu.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await tipostatusbiuService.deleteTipoStatusBiu(deleteId);
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
    <TipoStatusBiuGridMobileComponent
    data={tipostatusbiu}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <TipoStatusBiuGridDesktopComponent
    data={tipostatusbiu}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <TipoStatusBiuWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedTipoStatusBiu={selectedTipoStatusBiu}
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
export default TipoStatusBiuGrid;