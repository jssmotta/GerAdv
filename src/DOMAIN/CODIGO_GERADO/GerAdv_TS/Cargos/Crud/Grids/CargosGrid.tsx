//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { CargosEmpty } from "../../../Models/Cargos";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import CargosInc from "../Inc/Cargos";
import { ICargos } from "../../Interfaces/interface.Cargos";
import { CargosService } from "../../Services/Cargos.service";
import { CargosApi } from "../../Apis/ApiCargos";
import { CargosGridMobileComponent } from "../GridsMobile/Cargos";
import { CargosGridDesktopComponent } from "../GridsDesktop/Cargos";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterCargos } from "../../Filters/Cargos";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import CargosWindow from "./CargosWindow";

const CargosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [cargos, setCargos] = useState<ICargos[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedCargos, setSelectedCargos] = useState<ICargos>(CargosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new CargosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterCargos | undefined | null>(null);

    const cargosService = useMemo(() => {
      return new CargosService(
          new CargosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchCargos = async (filtro?: FilterCargos | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await cargosService.getList(filtro ?? {} as FilterCargos);
        setCargos(data);
      }
      else {
        const data = await cargosService.getAll(filtro ?? {} as FilterCargos);
        setCargos(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchCargos(currFilter);
    }, [showInc]);
  
    const handleRowClick = (cargos: ICargos) => {
      if (isMobile) {
        router.push(`/pages/cargos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${cargos.id}`);
      } else {
        setSelectedCargos(cargos);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/cargos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedCargos(CargosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchCargos(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const cargos = e.dataItem;		
        setDeleteId(cargos.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchCargos(currFilter);
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
           <CargosGridMobileComponent data={cargos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <CargosGridDesktopComponent data={cargos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <CargosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedCargos={selectedCargos}>       
        </CargosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default CargosGrid;