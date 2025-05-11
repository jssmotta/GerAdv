// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IEMPClassRiscos } from "../../Interfaces/interface.EMPClassRiscos";
import { EMPClassRiscosService } from "../../Services/EMPClassRiscos.service";
import { EMPClassRiscosApi } from "../../Apis/ApiEMPClassRiscos";
import EMPClassRiscosWindow from "./EMPClassRiscosWindow";

interface EMPClassRiscosWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const EMPClassRiscosWindowId: React.FC<EMPClassRiscosWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const empclassriscosService = useMemo(() => {
        return new EMPClassRiscosService(
            new EMPClassRiscosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IEMPClassRiscos | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await empclassriscosService.fetchEMPClassRiscosById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <EMPClassRiscosWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedEMPClassRiscos={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default EMPClassRiscosWindowId;