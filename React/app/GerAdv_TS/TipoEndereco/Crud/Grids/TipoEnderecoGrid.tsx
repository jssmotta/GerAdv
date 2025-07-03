//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { TipoEnderecoEmpty } from '../../../Models/TipoEndereco';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ITipoEndereco } from '../../Interfaces/interface.TipoEndereco';
import { TipoEnderecoService } from '../../Services/TipoEndereco.service';
import { TipoEnderecoApi } from '../../Apis/ApiTipoEndereco';
import { TipoEnderecoGridMobileComponent } from '../GridsMobile/TipoEndereco';
import { TipoEnderecoGridDesktopComponent } from '../GridsDesktop/TipoEndereco';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterTipoEndereco } from '../../Filters/TipoEndereco';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import TipoEnderecoWindow from './TipoEnderecoWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useTipoEnderecoList } from '../../Hooks/hookTipoEndereco';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const TipoEnderecoGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const tipoenderecoService = useMemo(() => {
    return new TipoEnderecoService(
    new TipoEnderecoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: tipoendereco, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useTipoEnderecoList(tipoenderecoService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedTipoEndereco, setSelectedTipoEndereco] = useState<ITipoEndereco>(TipoEnderecoEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterTipoEndereco | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterTipoEndereco | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterTipoEndereco);
};
// Handlers para o grid
const handleRowClick = (tipoendereco: ITipoEndereco) => {
  setSelectedTipoEndereco(tipoendereco);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedTipoEndereco(TipoEnderecoEmpty());
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
  const tipoendereco = e.dataItem;
  setDeleteId(tipoendereco.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await tipoenderecoService.deleteTipoEndereco(deleteId);
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
    <TipoEnderecoGridMobileComponent
    data={tipoendereco}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <TipoEnderecoGridDesktopComponent
    data={tipoendereco}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <TipoEnderecoWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedTipoEndereco={selectedTipoEndereco}
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
export default TipoEnderecoGrid;