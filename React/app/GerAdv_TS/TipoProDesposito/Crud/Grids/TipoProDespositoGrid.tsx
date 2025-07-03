//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { TipoProDespositoEmpty } from '../../../Models/TipoProDesposito';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ITipoProDesposito } from '../../Interfaces/interface.TipoProDesposito';
import { TipoProDespositoService } from '../../Services/TipoProDesposito.service';
import { TipoProDespositoApi } from '../../Apis/ApiTipoProDesposito';
import { TipoProDespositoGridMobileComponent } from '../GridsMobile/TipoProDesposito';
import { TipoProDespositoGridDesktopComponent } from '../GridsDesktop/TipoProDesposito';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterTipoProDesposito } from '../../Filters/TipoProDesposito';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import TipoProDespositoWindow from './TipoProDespositoWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useTipoProDespositoList } from '../../Hooks/hookTipoProDesposito';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const TipoProDespositoGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const tipoprodespositoService = useMemo(() => {
    return new TipoProDespositoService(
    new TipoProDespositoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: tipoprodesposito, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useTipoProDespositoList(tipoprodespositoService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedTipoProDesposito, setSelectedTipoProDesposito] = useState<ITipoProDesposito>(TipoProDespositoEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterTipoProDesposito | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterTipoProDesposito | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterTipoProDesposito);
};
// Handlers para o grid
const handleRowClick = (tipoprodesposito: ITipoProDesposito) => {
  setSelectedTipoProDesposito(tipoprodesposito);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedTipoProDesposito(TipoProDespositoEmpty());
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
  const tipoprodesposito = e.dataItem;
  setDeleteId(tipoprodesposito.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await tipoprodespositoService.deleteTipoProDesposito(deleteId);
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
    <TipoProDespositoGridMobileComponent
    data={tipoprodesposito}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <TipoProDespositoGridDesktopComponent
    data={tipoprodesposito}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <TipoProDespositoWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedTipoProDesposito={selectedTipoProDesposito}
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
export default TipoProDespositoGrid;