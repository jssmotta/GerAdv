//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { TipoContatoCRMEmpty } from '../../../Models/TipoContatoCRM';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ITipoContatoCRM } from '../../Interfaces/interface.TipoContatoCRM';
import { TipoContatoCRMService } from '../../Services/TipoContatoCRM.service';
import { TipoContatoCRMApi } from '../../Apis/ApiTipoContatoCRM';
import { TipoContatoCRMGridMobileComponent } from '../GridsMobile/TipoContatoCRM';
import { TipoContatoCRMGridDesktopComponent } from '../GridsDesktop/TipoContatoCRM';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterTipoContatoCRM } from '../../Filters/TipoContatoCRM';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import TipoContatoCRMWindow from './TipoContatoCRMWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useTipoContatoCRMList } from '../../Hooks/hookTipoContatoCRM';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const TipoContatoCRMGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const tipocontatocrmService = useMemo(() => {
    return new TipoContatoCRMService(
    new TipoContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: tipocontatocrm, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useTipoContatoCRMList(tipocontatocrmService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedTipoContatoCRM, setSelectedTipoContatoCRM] = useState<ITipoContatoCRM>(TipoContatoCRMEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterTipoContatoCRM | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterTipoContatoCRM | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterTipoContatoCRM);
};
// Handlers para o grid
const handleRowClick = (tipocontatocrm: ITipoContatoCRM) => {
  setSelectedTipoContatoCRM(tipocontatocrm);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedTipoContatoCRM(TipoContatoCRMEmpty());
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
  const tipocontatocrm = e.dataItem;
  setDeleteId(tipocontatocrm.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await tipocontatocrmService.deleteTipoContatoCRM(deleteId);
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
    <TipoContatoCRMGridMobileComponent
    data={tipocontatocrm}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <TipoContatoCRMGridDesktopComponent
    data={tipocontatocrm}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <TipoContatoCRMWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedTipoContatoCRM={selectedTipoContatoCRM}
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
export default TipoContatoCRMGrid;