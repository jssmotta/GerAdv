// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IProDepositos } from "../../Interfaces/interface.ProDepositos";
import { ProDepositosService } from "../../Services/ProDepositos.service";
import { ProDepositosApi } from "../../Apis/ApiProDepositos";
import ProDepositosWindow from "./ProDepositosWindow";

interface ProDepositosWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ProDepositosWindowId: React.FC<ProDepositosWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const prodepositosService = useMemo(() => {
        return new ProDepositosService(
            new ProDepositosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IProDepositos | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await prodepositosService.fetchProDepositosById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ProDepositosWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedProDepositos={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ProDepositosWindowId;