//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { TipoProDespositoEmpty } from "../../../Models/TipoProDesposito";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { ITipoProDesposito } from "../../Interfaces/interface.TipoProDesposito";
import { TipoProDespositoService } from "../../Services/TipoProDesposito.service";
import { TipoProDespositoApi } from "../../Apis/ApiTipoProDesposito";
import { TipoProDespositoGridMobileComponent } from "../GridsMobile/TipoProDesposito";
import { TipoProDespositoGridDesktopComponent } from "../GridsDesktop/TipoProDesposito";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterTipoProDesposito } from "../../Filters/TipoProDesposito";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import TipoProDespositoWindow from "./TipoProDespositoWindow";

const TipoProDespositoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [tipoprodesposito, setTipoProDesposito] = useState<ITipoProDesposito[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedTipoProDesposito, setSelectedTipoProDesposito] = useState<ITipoProDesposito>(TipoProDespositoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new TipoProDespositoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterTipoProDesposito | undefined | null>(null);

    const tipoprodespositoService = useMemo(() => {
      return new TipoProDespositoService(
          new TipoProDespositoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchTipoProDesposito = async (filtro?: FilterTipoProDesposito | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await tipoprodespositoService.getList(filtro ?? {} as FilterTipoProDesposito);
        setTipoProDesposito(data);
      }
      else {
        const data = await tipoprodespositoService.getAll(filtro ?? {} as FilterTipoProDesposito);
        setTipoProDesposito(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchTipoProDesposito(currFilter);
    }, [showInc]);
  
    const handleRowClick = (tipoprodesposito: ITipoProDesposito) => {
      if (isMobile) {
        router.push(`/pages/tipoprodesposito/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${tipoprodesposito.id}`);
      } else {
        setSelectedTipoProDesposito(tipoprodesposito);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/tipoprodesposito/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedTipoProDesposito(TipoProDespositoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchTipoProDesposito(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const tipoprodesposito = e.dataItem;		
        setDeleteId(tipoprodesposito.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchTipoProDesposito(currFilter);
            } catch {
            // falta uma mensagem de erro
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

    return (
      <>
        <AppGridToolbar onAdd={handleAdd} />    

        {isMobile ?
           <TipoProDespositoGridMobileComponent data={tipoprodesposito} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <TipoProDespositoGridDesktopComponent data={tipoprodesposito} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <TipoProDespositoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedTipoProDesposito={selectedTipoProDesposito}>       
        </TipoProDespositoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default TipoProDespositoGrid;