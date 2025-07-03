import React from 'react';
import { render } from '@testing-library/react';
import RecadosIncContainer from '@/app/GerAdv_TS/Recados/Components/RecadosIncContainer';
// RecadosIncContainer.test.tsx
// Mock do RecadosInc
jest.mock('@/app/GerAdv_TS/Recados/Crud/Inc/Recados', () => (props: any) => (
<div data-testid='recados-inc-mock' {...props} />
));
describe('RecadosIncContainer', () => {
  it('deve renderizar RecadosInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <RecadosIncContainer id={id} navigator={mockNavigator} />
  );
  const recadosInc = getByTestId('recados-inc-mock');
  expect(recadosInc).toBeInTheDocument();
  expect(recadosInc.getAttribute('id')).toBe(id.toString());

});
});