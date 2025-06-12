//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { GUTTipoEmpty } from '../../../Models/GUTTipo';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IGUTTipo } from '../../Interfaces/interface.GUTTipo';
import { GUTTipoService } from '../../Services/GUTTipo.service';
import { GUTTipoApi } from '../../Apis/ApiGUTTipo';
import { GUTTipoGridMobileComponent } from '../GridsMobile/GUTTipo';
import { GUTTipoGridDesktopComponent } from '../GridsDesktop/GUTTipo';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterGUTTipo } from '../../Filters/GUTTipo';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import GUTTipoWindow from './GUTTipoWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useGUTTipoList } from '../../Hooks/hookGUTTipo';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const GUTTipoGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const guttipoService = useMemo(() => {
    return new GUTTipoService(
    new GUTTipoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: guttipo, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useGUTTipoList(guttipoService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedGUTTipo, setSelectedGUTTipo] = useState<IGUTTipo>(GUTTipoEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterGUTTipo | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterGUTTipo | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterGUTTipo);
};
// Handlers para o grid
const handleRowClick = (guttipo: IGUTTipo) => {
  setSelectedGUTTipo(guttipo);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedGUTTipo(GUTTipoEmpty());
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
  const guttipo = e.dataItem;
  setDeleteId(guttipo.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await guttipoService.deleteGUTTipo(deleteId);
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
    <GUTTipoGridMobileComponent
    data={guttipo}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <GUTTipoGridDesktopComponent
    data={guttipo}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <GUTTipoWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedGUTTipo={selectedGUTTipo}
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
export default GUTTipoGrid;