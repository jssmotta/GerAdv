//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { HonorariosDadosContratoEmpty } from "../../../Models/HonorariosDadosContrato";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IHonorariosDadosContrato } from "../../Interfaces/interface.HonorariosDadosContrato";
import { HonorariosDadosContratoService } from "../../Services/HonorariosDadosContrato.service";
import { HonorariosDadosContratoApi } from "../../Apis/ApiHonorariosDadosContrato";
import { HonorariosDadosContratoGridMobileComponent } from "../GridsMobile/HonorariosDadosContrato";
import { HonorariosDadosContratoGridDesktopComponent } from "../GridsDesktop/HonorariosDadosContrato";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterHonorariosDadosContrato } from "../../Filters/HonorariosDadosContrato";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import HonorariosDadosContratoWindow from "./HonorariosDadosContratoWindow";

const HonorariosDadosContratoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [honorariosdadoscontrato, setHonorariosDadosContrato] = useState<IHonorariosDadosContrato[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedHonorariosDadosContrato, setSelectedHonorariosDadosContrato] = useState<IHonorariosDadosContrato>(HonorariosDadosContratoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new HonorariosDadosContratoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterHonorariosDadosContrato | undefined | null>(null);

    const honorariosdadoscontratoService = useMemo(() => {
      return new HonorariosDadosContratoService(
          new HonorariosDadosContratoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchHonorariosDadosContrato = async (filtro?: FilterHonorariosDadosContrato | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await honorariosdadoscontratoService.getAll(filtro ?? {} as FilterHonorariosDadosContrato);
        setHonorariosDadosContrato(data);
      }
      else {
        const data = await honorariosdadoscontratoService.getAll(filtro ?? {} as FilterHonorariosDadosContrato);
        setHonorariosDadosContrato(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchHonorariosDadosContrato(currFilter);
    }, [showInc]);
  
    const handleRowClick = (honorariosdadoscontrato: IHonorariosDadosContrato) => {
      if (isMobile) {
        router.push(`/pages/honorariosdadoscontrato/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${honorariosdadoscontrato.id}`);
      } else {
        setSelectedHonorariosDadosContrato(honorariosdadoscontrato);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/honorariosdadoscontrato/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedHonorariosDadosContrato(HonorariosDadosContratoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchHonorariosDadosContrato(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const honorariosdadoscontrato = e.dataItem;		
        setDeleteId(honorariosdadoscontrato.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchHonorariosDadosContrato(currFilter);
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
            
        {isMobile ?
           <HonorariosDadosContratoGridMobileComponent data={honorariosdadoscontrato} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <HonorariosDadosContratoGridDesktopComponent data={honorariosdadoscontrato} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <HonorariosDadosContratoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedHonorariosDadosContrato={selectedHonorariosDadosContrato}>       
        </HonorariosDadosContratoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default HonorariosDadosContratoGrid;