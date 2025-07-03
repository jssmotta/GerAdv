import React from 'react';
import { render } from '@testing-library/react';
import AgendaRecordsIncContainer from '@/app/GerAdv_TS/AgendaRecords/Components/AgendaRecordsIncContainer';
// AgendaRecordsIncContainer.test.tsx
// Mock do AgendaRecordsInc
jest.mock('@/app/GerAdv_TS/AgendaRecords/Crud/Inc/AgendaRecords', () => (props: any) => (
<div data-testid='agendarecords-inc-mock' {...props} />
));
describe('AgendaRecordsIncContainer', () => {
  it('deve renderizar AgendaRecordsInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <AgendaRecordsIncContainer id={id} navigator={mockNavigator} />
  );
  const agendarecordsInc = getByTestId('agendarecords-inc-mock');
  expect(agendarecordsInc).toBeInTheDocument();
  expect(agendarecordsInc.getAttribute('id')).toBe(id.toString());

});
});