//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { GruposEmpresasCliEmpty } from '../../../Models/GruposEmpresasCli';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IGruposEmpresasCli } from '../../Interfaces/interface.GruposEmpresasCli';
import { GruposEmpresasCliService } from '../../Services/GruposEmpresasCli.service';
import { GruposEmpresasCliApi } from '../../Apis/ApiGruposEmpresasCli';
import { GruposEmpresasCliGridMobileComponent } from '../GridsMobile/GruposEmpresasCli';
import { GruposEmpresasCliGridDesktopComponent } from '../GridsDesktop/GruposEmpresasCli';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterGruposEmpresasCli } from '../../Filters/GruposEmpresasCli';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import GruposEmpresasCliWindow from './GruposEmpresasCliWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useGruposEmpresasCliList } from '../../Hooks/hookGruposEmpresasCli';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const GruposEmpresasCliGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const gruposempresascliService = useMemo(() => {
    return new GruposEmpresasCliService(
    new GruposEmpresasCliApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: gruposempresascli, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useGruposEmpresasCliList(gruposempresascliService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedGruposEmpresasCli, setSelectedGruposEmpresasCli] = useState<IGruposEmpresasCli>(GruposEmpresasCliEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterGruposEmpresasCli | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterGruposEmpresasCli | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterGruposEmpresasCli);
};
// Handlers para o grid
const handleRowClick = (gruposempresascli: IGruposEmpresasCli) => {
  setSelectedGruposEmpresasCli(gruposempresascli);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedGruposEmpresasCli(GruposEmpresasCliEmpty());
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
  const gruposempresascli = e.dataItem;
  setDeleteId(gruposempresascli.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await gruposempresascliService.deleteGruposEmpresasCli(deleteId);
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
    <GruposEmpresasCliGridMobileComponent
    data={gruposempresascli}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <GruposEmpresasCliGridDesktopComponent
    data={gruposempresascli}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <GruposEmpresasCliWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedGruposEmpresasCli={selectedGruposEmpresasCli}
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
export default GruposEmpresasCliGrid;