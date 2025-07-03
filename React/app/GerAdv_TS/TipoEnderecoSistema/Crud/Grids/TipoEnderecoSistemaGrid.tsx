//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { TipoEnderecoSistemaEmpty } from '../../../Models/TipoEnderecoSistema';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ITipoEnderecoSistema } from '../../Interfaces/interface.TipoEnderecoSistema';
import { TipoEnderecoSistemaService } from '../../Services/TipoEnderecoSistema.service';
import { TipoEnderecoSistemaApi } from '../../Apis/ApiTipoEnderecoSistema';
import { TipoEnderecoSistemaGridMobileComponent } from '../GridsMobile/TipoEnderecoSistema';
import { TipoEnderecoSistemaGridDesktopComponent } from '../GridsDesktop/TipoEnderecoSistema';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterTipoEnderecoSistema } from '../../Filters/TipoEnderecoSistema';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import TipoEnderecoSistemaWindow from './TipoEnderecoSistemaWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useTipoEnderecoSistemaList } from '../../Hooks/hookTipoEnderecoSistema';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const TipoEnderecoSistemaGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const tipoenderecosistemaService = useMemo(() => {
    return new TipoEnderecoSistemaService(
    new TipoEnderecoSistemaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: tipoenderecosistema, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useTipoEnderecoSistemaList(tipoenderecosistemaService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedTipoEnderecoSistema, setSelectedTipoEnderecoSistema] = useState<ITipoEnderecoSistema>(TipoEnderecoSistemaEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterTipoEnderecoSistema | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterTipoEnderecoSistema | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterTipoEnderecoSistema);
};
// Handlers para o grid
const handleRowClick = (tipoenderecosistema: ITipoEnderecoSistema) => {
  setSelectedTipoEnderecoSistema(tipoenderecosistema);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedTipoEnderecoSistema(TipoEnderecoSistemaEmpty());
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
  const tipoenderecosistema = e.dataItem;
  setDeleteId(tipoenderecosistema.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await tipoenderecosistemaService.deleteTipoEnderecoSistema(deleteId);
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
    <TipoEnderecoSistemaGridMobileComponent
    data={tipoenderecosistema}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <TipoEnderecoSistemaGridDesktopComponent
    data={tipoenderecosistema}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <TipoEnderecoSistemaWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedTipoEnderecoSistema={selectedTipoEnderecoSistema}
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
export default TipoEnderecoSistemaGrid;