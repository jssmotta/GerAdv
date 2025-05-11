//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ServicosEmpty } from "../../../Models/Servicos";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IServicos } from "../../Interfaces/interface.Servicos";
import { ServicosService } from "../../Services/Servicos.service";
import { ServicosApi } from "../../Apis/ApiServicos";
import { ServicosGridMobileComponent } from "../GridsMobile/Servicos";
import { ServicosGridDesktopComponent } from "../GridsDesktop/Servicos";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterServicos } from "../../Filters/Servicos";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ServicosWindow from "./ServicosWindow";

const ServicosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [servicos, setServicos] = useState<IServicos[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedServicos, setSelectedServicos] = useState<IServicos>(ServicosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ServicosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterServicos | undefined | null>(null);

    const servicosService = useMemo(() => {
      return new ServicosService(
          new ServicosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchServicos = async (filtro?: FilterServicos | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await servicosService.getList(filtro ?? {} as FilterServicos);
        setServicos(data);
      }
      else {
        const data = await servicosService.getAll(filtro ?? {} as FilterServicos);
        setServicos(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchServicos(currFilter);
    }, [showInc]);
  
    const handleRowClick = (servicos: IServicos) => {
      if (isMobile) {
        router.push(`/pages/servicos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${servicos.id}`);
      } else {
        setSelectedServicos(servicos);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/servicos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedServicos(ServicosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchServicos(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const servicos = e.dataItem;		
        setDeleteId(servicos.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchServicos(currFilter);
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
           <ServicosGridMobileComponent data={servicos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ServicosGridDesktopComponent data={servicos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ServicosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedServicos={selectedServicos}>       
        </ServicosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ServicosGrid;