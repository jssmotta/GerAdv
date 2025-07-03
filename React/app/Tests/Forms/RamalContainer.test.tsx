import React from 'react';
import { render } from '@testing-library/react';
import RamalIncContainer from '@/app/GerAdv_TS/Ramal/Components/RamalIncContainer';
// RamalIncContainer.test.tsx
// Mock do RamalInc
jest.mock('@/app/GerAdv_TS/Ramal/Crud/Inc/Ramal', () => (props: any) => (
<div data-testid='ramal-inc-mock' {...props} />
));
describe('RamalIncContainer', () => {
  it('deve renderizar RamalInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <RamalIncContainer id={id} navigator={mockNavigator} />
  );
  const ramalInc = getByTestId('ramal-inc-mock');
  expect(ramalInc).toBeInTheDocument();
  expect(ramalInc.getAttribute('id')).toBe(id.toString());

});
});