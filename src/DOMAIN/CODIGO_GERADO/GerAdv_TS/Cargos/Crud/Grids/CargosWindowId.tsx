// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { ICargos } from "../../Interfaces/interface.Cargos";
import { CargosService } from "../../Services/Cargos.service";
import { CargosApi } from "../../Apis/ApiCargos";
import CargosWindow from "./CargosWindow";

interface CargosWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const CargosWindowId: React.FC<CargosWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const cargosService = useMemo(() => {
        return new CargosService(
            new CargosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<ICargos | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await cargosService.fetchCargosById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <CargosWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedCargos={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default CargosWindowId;