// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IHonorariosDadosContrato } from "../../Interfaces/interface.HonorariosDadosContrato";
import { HonorariosDadosContratoService } from "../../Services/HonorariosDadosContrato.service";
import { HonorariosDadosContratoApi } from "../../Apis/ApiHonorariosDadosContrato";
import HonorariosDadosContratoWindow from "./HonorariosDadosContratoWindow";

interface HonorariosDadosContratoWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const HonorariosDadosContratoWindowId: React.FC<HonorariosDadosContratoWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const honorariosdadoscontratoService = useMemo(() => {
        return new HonorariosDadosContratoService(
            new HonorariosDadosContratoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IHonorariosDadosContrato | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await honorariosdadoscontratoService.fetchHonorariosDadosContratoById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <HonorariosDadosContratoWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedHonorariosDadosContrato={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default HonorariosDadosContratoWindowId;