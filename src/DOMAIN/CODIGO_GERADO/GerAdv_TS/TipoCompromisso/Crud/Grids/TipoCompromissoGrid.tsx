//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { TipoCompromissoEmpty } from "../../../Models/TipoCompromisso";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import TipoCompromissoInc from "../Inc/TipoCompromisso";
import { ITipoCompromisso } from "../../Interfaces/interface.TipoCompromisso";
import { TipoCompromissoService } from "../../Services/TipoCompromisso.service";
import { TipoCompromissoApi } from "../../Apis/ApiTipoCompromisso";
import { TipoCompromissoGridMobileComponent } from "../GridsMobile/TipoCompromisso";
import { TipoCompromissoGridDesktopComponent } from "../GridsDesktop/TipoCompromisso";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterTipoCompromisso } from "../../Filters/TipoCompromisso";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import TipoCompromissoWindow from "./TipoCompromissoWindow";

const TipoCompromissoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [tipocompromisso, setTipoCompromisso] = useState<ITipoCompromisso[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedTipoCompromisso, setSelectedTipoCompromisso] = useState<ITipoCompromisso>(TipoCompromissoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new TipoCompromissoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterTipoCompromisso | undefined | null>(null);

    const tipocompromissoService = useMemo(() => {
      return new TipoCompromissoService(
          new TipoCompromissoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchTipoCompromisso = async (filtro?: FilterTipoCompromisso | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await tipocompromissoService.getList(filtro ?? {} as FilterTipoCompromisso);
        setTipoCompromisso(data);
      }
      else {
        const data = await tipocompromissoService.getAll(filtro ?? {} as FilterTipoCompromisso);
        setTipoCompromisso(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchTipoCompromisso(currFilter);
    }, [showInc]);
  
    const handleRowClick = (tipocompromisso: ITipoCompromisso) => {
      if (isMobile) {
        router.push(`/pages/tipocompromisso/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${tipocompromisso.id}`);
      } else {
        setSelectedTipoCompromisso(tipocompromisso);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/tipocompromisso/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedTipoCompromisso(TipoCompromissoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchTipoCompromisso(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const tipocompromisso = e.dataItem;		
        setDeleteId(tipocompromisso.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchTipoCompromisso(currFilter);
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
           <TipoCompromissoGridMobileComponent data={tipocompromisso} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <TipoCompromissoGridDesktopComponent data={tipocompromisso} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <TipoCompromissoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedTipoCompromisso={selectedTipoCompromisso}>       
        </TipoCompromissoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default TipoCompromissoGrid;