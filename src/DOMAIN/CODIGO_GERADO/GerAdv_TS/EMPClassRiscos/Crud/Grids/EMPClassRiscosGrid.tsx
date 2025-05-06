//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { EMPClassRiscosEmpty } from "../../../Models/EMPClassRiscos";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IEMPClassRiscos } from "../../Interfaces/interface.EMPClassRiscos";
import { EMPClassRiscosService } from "../../Services/EMPClassRiscos.service";
import { EMPClassRiscosApi } from "../../Apis/ApiEMPClassRiscos";
import { EMPClassRiscosGridMobileComponent } from "../GridsMobile/EMPClassRiscos";
import { EMPClassRiscosGridDesktopComponent } from "../GridsDesktop/EMPClassRiscos";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterEMPClassRiscos } from "../../Filters/EMPClassRiscos";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import EMPClassRiscosWindow from "./EMPClassRiscosWindow";

const EMPClassRiscosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [empclassriscos, setEMPClassRiscos] = useState<IEMPClassRiscos[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedEMPClassRiscos, setSelectedEMPClassRiscos] = useState<IEMPClassRiscos>(EMPClassRiscosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new EMPClassRiscosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterEMPClassRiscos | undefined | null>(null);

    const empclassriscosService = useMemo(() => {
      return new EMPClassRiscosService(
          new EMPClassRiscosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchEMPClassRiscos = async (filtro?: FilterEMPClassRiscos | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await empclassriscosService.getList(filtro ?? {} as FilterEMPClassRiscos);
        setEMPClassRiscos(data);
      }
      else {
        const data = await empclassriscosService.getAll(filtro ?? {} as FilterEMPClassRiscos);
        setEMPClassRiscos(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchEMPClassRiscos(currFilter);
    }, [showInc]);
  
    const handleRowClick = (empclassriscos: IEMPClassRiscos) => {
      if (isMobile) {
        router.push(`/pages/empclassriscos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${empclassriscos.id}`);
      } else {
        setSelectedEMPClassRiscos(empclassriscos);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/empclassriscos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedEMPClassRiscos(EMPClassRiscosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchEMPClassRiscos(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const empclassriscos = e.dataItem;		
        setDeleteId(empclassriscos.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchEMPClassRiscos(currFilter);
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
           <EMPClassRiscosGridMobileComponent data={empclassriscos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <EMPClassRiscosGridDesktopComponent data={empclassriscos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <EMPClassRiscosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedEMPClassRiscos={selectedEMPClassRiscos}>       
        </EMPClassRiscosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default EMPClassRiscosGrid;