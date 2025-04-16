//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { TipoStatusBiuEmpty } from "../../../Models/TipoStatusBiu";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import TipoStatusBiuInc from "../Inc/TipoStatusBiu";
import { ITipoStatusBiu } from "../../Interfaces/interface.TipoStatusBiu";
import { TipoStatusBiuService } from "../../Services/TipoStatusBiu.service";
import { TipoStatusBiuApi } from "../../Apis/ApiTipoStatusBiu";
import { TipoStatusBiuGridMobileComponent } from "../GridsMobile/TipoStatusBiu";
import { TipoStatusBiuGridDesktopComponent } from "../GridsDesktop/TipoStatusBiu";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterTipoStatusBiu } from "../../Filters/TipoStatusBiu";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import TipoStatusBiuWindow from "./TipoStatusBiuWindow";

const TipoStatusBiuGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [tipostatusbiu, setTipoStatusBiu] = useState<ITipoStatusBiu[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedTipoStatusBiu, setSelectedTipoStatusBiu] = useState<ITipoStatusBiu>(TipoStatusBiuEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new TipoStatusBiuApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterTipoStatusBiu | undefined | null>(null);

    const tipostatusbiuService = useMemo(() => {
      return new TipoStatusBiuService(
          new TipoStatusBiuApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchTipoStatusBiu = async (filtro?: FilterTipoStatusBiu | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await tipostatusbiuService.getList(filtro ?? {} as FilterTipoStatusBiu);
        setTipoStatusBiu(data);
      }
      else {
        const data = await tipostatusbiuService.getAll(filtro ?? {} as FilterTipoStatusBiu);
        setTipoStatusBiu(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchTipoStatusBiu(currFilter);
    }, [showInc]);
  
    const handleRowClick = (tipostatusbiu: ITipoStatusBiu) => {
      if (isMobile) {
        router.push(`/pages/tipostatusbiu/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${tipostatusbiu.id}`);
      } else {
        setSelectedTipoStatusBiu(tipostatusbiu);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/tipostatusbiu/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedTipoStatusBiu(TipoStatusBiuEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchTipoStatusBiu(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const tipostatusbiu = e.dataItem;		
        setDeleteId(tipostatusbiu.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchTipoStatusBiu(currFilter);
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
           <TipoStatusBiuGridMobileComponent data={tipostatusbiu} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <TipoStatusBiuGridDesktopComponent data={tipostatusbiu} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <TipoStatusBiuWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedTipoStatusBiu={selectedTipoStatusBiu}>       
        </TipoStatusBiuWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default TipoStatusBiuGrid;